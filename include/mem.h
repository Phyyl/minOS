
void memcpy(const void* dst, const void* src, size_t num)
{
	char* cdst = (char*)dst;
	char* csrc = (char*)src;

	for (size_t i = 0; i < num; i++)
	{
		cdst[i] = csrc[i];
	}
}

void memset(const void* ptr, int value, size_t num)
{
	unsigned char* cptr = (unsigned char*)ptr;

	while (num--)
	{
		cptr[num] = (unsigned char)value;
	}
}
