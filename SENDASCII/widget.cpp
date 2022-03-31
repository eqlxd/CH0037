#include "widget.h"
#include "ui_widget.h"
#include <QByteArray>
#include <QThread>
#include<QDebug>
#include <QString>
#include <QByteArray>
#include <QThread>
#include <QTimer>

Widget::Widget(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::Widget)
{
    ui->setupUi(this);




    port.setPortName("COM5");//选择串口号
    port.open(QIODevice::WriteOnly);
    port.setBaudRate(9600);
    port.setDataBits(QSerialPort::Data8);//8位数据位
    port.setParity(QSerialPort::NoParity);//无检验
    port.setStopBits(QSerialPort::OneStop);//1位停止位
    port.setFlowControl(QSerialPort::NoFlowControl);//无硬件控制

    QTimer *timer = new QTimer();
    connect(timer,SIGNAL(timeout()),this,SLOT(contSend()));
    timer->start(50);

    QTimer *timer01 = new QTimer();
    connect(timer01,SIGNAL(timeout()),this,SLOT(getdata()));
    timer01->start(50);
}

Widget::~Widget()
{
    delete ui;
    port.close();
}




void Widget::contSend()
{

    buf = "$001,";
    buf.append(trans);
    buf.append("#");
    byte = buf.toUtf8();
    port.write(byte);
    port.flush();
    qDebug()<<byte;

}

void Widget::getdata()
{
    trans = ui->lineEdit->text();
}

