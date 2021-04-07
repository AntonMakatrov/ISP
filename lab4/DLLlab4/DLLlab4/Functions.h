#pragma once
#ifdef FUNCTIONS_EXPORTS
#define FUNCTIONS_API __declspec(dllexport)
#else
#define FUNCTIONS_API __declspec(dllimport)
#endif


extern "C" FUNCTIONS_API  float __stdcall Min(float a, float b);

extern "C" FUNCTIONS_API float __stdcall Max(float a, float b);

extern "C" FUNCTIONS_API float __stdcall Abs(float a);

extern "C" FUNCTIONS_API float __cdecl Pow(float a, int b);

extern "C" FUNCTIONS_API int __cdecl Fact(int a);

extern "C" FUNCTIONS_API unsigned long long __cdecl Fibonacci(int a);