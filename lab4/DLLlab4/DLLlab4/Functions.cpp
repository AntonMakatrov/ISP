#include "pch.h"
#include <utility>
#include <limits.h>
#include "Functions.h"

float __stdcall Min(float a, float b)
{
	return (a < b) ? a : b;
}
float __stdcall Max(float a, float b)
{
	return (a > b) ? a : b;
}

float __stdcall Abs(float a)
{
	return (a < 0) ? -a : a;
}

float __cdecl Pow(float a, int b)
{
	if (b == 1)
		return a;
	if (!b)
		return 1;
	return a * Pow(a, --b);
}


int __cdecl Fact(int a)
{
	if (a < 0) 
		return 0; 
	if (a == 0) 
		return 1; 
	else 
		return a * Fact(a - 1);
}

unsigned long long __cdecl Fibonacci(int a)
{
	if (a == 0) return 0;
	if (a == 1 || a == 2) return 1;

	return Fibonacci(a - 1) + Fibonacci(a - 2);
}