#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QSerialPort>
#include <QSerialPortInfo>

QT_BEGIN_NAMESPACE
namespace Ui { class Widget; }
QT_END_NAMESPACE

class Widget : public QWidget
{
    Q_OBJECT

public:
    Widget(QWidget *parent = nullptr);
    ~Widget();

private slots:

    void contSend();
    void getdata();

private:
    Ui::Widget *ui;
    QString buf;
    QByteArray byte;
    QSerialPort port;
    QString trans;
};
#endif // WIDGET_H
