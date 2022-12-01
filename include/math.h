#ifndef MATH_H
#define MATH_H

int pow(int x, int n)
{
	if (n <= 0) return 1;

	while (--n) x *= x;

	return x;
}

#endif // MATH_H