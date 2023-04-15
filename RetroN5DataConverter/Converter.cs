using System;
using System.IO;
using CrCHash;
using zlib;

namespace RetroN5DataConverter
{
	public static class Converter
	{
		public static readonly uint RETRON_DATA_MAGIC = 894325842u;

		private static readonly ushort RETRON_DATA_FLG_ZLIB_PACKED = 1;

		public static readonly ushort RETRON_DATA_FORMAT_VER = 1;

		private static void CopyStream(Stream input, Stream output, uint size)
		{
			byte[] buffer = new byte[size];
			int num = 0;
			while ((num = input.Read(buffer, 0, (int)size)) > 0)
			{
				output.Write(buffer, 0, num);
			}
			output.Flush();
		}

		private static bool ScanSection(byte[] data, int startIndex, int length)
		{
			length += startIndex;
			for (int i = startIndex; i < length; i++)
				if (data[i] != 0xFF)
					return true;
			return false;
		}

		private static byte[] CompressData(byte[] data)
		{
			using MemoryStream memoryStream = new();
			using ZOutputStream zOutputStream = new(memoryStream, -1);
			using Stream input = new MemoryStream(data);
			CopyStream(input, zOutputStream, 4096u);
			zOutputStream.finish();

			return memoryStream.ToArray();
		}

		private static byte[] DecompressData(byte[] data, uint size)
		{
			using MemoryStream memoryStream = new();
			using ZOutputStream zOutputStream = new(memoryStream);
			using Stream input = new MemoryStream(data);
			CopyStream(input, zOutputStream, size);
			zOutputStream.finish();

			return memoryStream.ToArray();
		}

		public static byte[] ExtractRetroN5Data(RetroN5Data data, bool trim)
		{
			byte[] rawData = ((data.flags & RETRON_DATA_FLG_ZLIB_PACKED) != 0) ? DecompressData(data.data, data.origSize) : data.data;

			if (trim && rawData.Length == 0x22000) // 136 KB
			{
				byte[] trimData;

				if (ScanSection(rawData, 0, 0x10000) && !ScanSection(rawData, 0x10000, 0x10000))
				{
					trimData = new byte[0x10000];
					Array.Copy(rawData, trimData, 0x10000);
					return trimData;
				}
				if (ScanSection(rawData, 0, 0x20000))
				{
					trimData = new byte[0x20000];
					Array.Copy(rawData, trimData, 0x20000);
					return trimData;
				}
				if (ScanSection(rawData, 0x20000, 512) && !ScanSection(rawData, 0x20000 + 512, 0x2000 - 512))
				{
					trimData = new byte[512];
					Array.Copy(rawData, 0x20000, trimData, 0, 512);
					return trimData;
				}
				if (ScanSection(rawData, 0x20000, 0x2000))
				{
					trimData = new byte[0x2000];
					Array.Copy(rawData, 0x20000, trimData, 0, 0x2000);
					return trimData;
				}

				// If none of those cases were applicable, the save data is uninitialized.
				// The caller program should issue a warning about uninitialized save data.
			}

			return rawData;
		}

		public static RetroN5Data CreateRetroN5Data(byte[] array, bool compress)
		{
			uint origSize = (uint)array.LongLength;
			uint crc = (uint)BitConverter.ToInt32(CRC.CRC32(array), 0);
			if (compress)
				array = CompressData(array);
			RetroN5Data result = default;
			result.magic = RETRON_DATA_MAGIC;
			result.fmtVer = RETRON_DATA_FORMAT_VER;
			result.flags = compress ? (ushort)1 : (ushort)0;
			result.origSize = origSize;
			result.packedSize = (uint)array.LongLength;
			result.dataOffset = 24u;
			result.crc32 = crc;
			result.data = array;
			return result;
		}
	}
}
