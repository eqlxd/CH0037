#ifndef PRACDLL_A_GLOBAL_H
#define PRACDLL_A_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(PRACDLL_A_LIBRARY)
#  define PRACDLL_A_EXPORT Q_DECL_EXPORT
#else
#  define PRACDLL_A_EXPORT Q_DECL_IMPORT
#endif

#endif // PRACDLL_A_GLOBAL_H
