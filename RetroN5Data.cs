namespace RetroN5FileConverter;

public struct RetroN5Data
{
	public uint magic;
	public ushort fmtVer;
	public ushort flags;
	public uint origSize;
	public uint packedSize;
	public uint dataOffset;
	public uint crc32;
	public byte[] data;
}