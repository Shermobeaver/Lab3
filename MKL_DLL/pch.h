#ifndef PCH_H
#define PCH_H

#include "framework.h"
#include "mkl.h"

extern "C" _declspec(dllexport) double Interpol(const double* Contents, const int nx, const int ny, const double step, double* res);

#endif //PCH_H
