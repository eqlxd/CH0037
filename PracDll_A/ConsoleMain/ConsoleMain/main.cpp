#include <QCoreApplication>
#include <QDebug>
#include <QDir>
#include "pracdll_a.h"
#include "PracDll_A_global.h"

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    QDir pluginsDir(QCoreApplication::applicationDirPath());
    PracDll_A demodll;
    int c = demodll.add(1,2);
    qDebug()<<c;
    qDebug()<<"c";
    qDebug()<<pluginsDir.dirName();
    pluginsDir.cdUp();
    qDebug()<<pluginsDir.absolutePath();
    qDebug()<<pluginsDir.dirName();
    pluginsDir.cdUp();
    qDebug()<<pluginsDir.absolutePath();
    qDebug()<<pluginsDir.dirName();
    pluginsDir.cdUp();
    qDebug()<<pluginsDir.absolutePath();
    qDebug()<<pluginsDir.dirName();
    pluginsDir.cdUp();
    qDebug()<<pluginsDir.absolutePath();
    qDebug()<<pluginsDir.dirName();
    return a.exec();

}
