using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace VideoMonitor.CommonClass
{
    class PelcoD
    {
        private string watchdir = "";//��ط���
        private static readonly byte STX = 0xFF;//ͬ���ֽ�

        #region  ��ط���Ͷ�ʱ���ʵ��
        public string WatchDir
        {
            get
            {
                return watchdir;
            }
            set
            {
                watchdir = value;
            }
        }
        #endregion

        #region ����ָ���
        #region ָ����1
        private const byte FocusNear = 0x01;//���Ӿ۽�
        private const byte IrisOpen = 0x02;//��С��Ȧ
        private const byte IrisClose = 0x04;//���ӹ�Ȧ
        private const byte CameraOnOff = 0x08;//������򿪺͹ر�
        private const byte AutoManualScan = 0x10;//�Զ����ֶ�ɨ��
        private const byte Sense = 0x80;//Sence��
        #endregion

        #region  ָ����2
        private const byte PanRight = 0x02;//��
        private const byte PanLeft = 0x04;//��
        private const byte TiltUp = 0x08;//��
        private const byte TiltDown = 0x10;//��
        private const byte ZoomTele = 0x20;//���ӶԽ�
        private const byte ZoomWide = 0x40;//��С�Խ�
        private const byte FocusFar = 0x80;//��С�۽�
        #endregion

        #region ��ͷ����ƽ�Ƶ��ٶ�
        private const byte PanSpeedMin = 0x00;//ֹͣ
        private const byte PanSpeedMax = 0xFF;//�����
        #endregion

        #region ��ͷ�����ƶ����ٶ�
        private const byte TiltSpeedMin = 0x00;//ֹͣ
        private const byte TiltSpeedMax = 0x3F;//�����
        #endregion
        #endregion

        #region ��̨����ö��
        public enum Switch { On = 0x01, Off = 0x02 }//��ˢ����
        public enum Focus { Near = FocusNear, Far = FocusFar }//�۽�����
        public enum Zoom { Wide = ZoomWide, Tele = ZoomTele }//�Խ�����
        public enum Tilt { Up = TiltUp, Down = TiltDown }//���¿���
        public enum Pan { Left = PanLeft, Right = PanRight }//���ҿ���
        public enum Scan { Auto, Manual }//�Զ����ֶ�����
        public enum Iris { Open = IrisOpen, Close = IrisClose }//��Ȧ����
        #endregion

        #region ��̨���Ʒ���
        //��ˢ����
        public byte[] CameraSwitch(uint deviceAddress, Switch action)
        {
            byte m_action = CameraOnOff;
            if (action == Switch.On)
                m_action = CameraOnOff + Sense;
            return Message.GetMessage(deviceAddress, m_action, 0x00, 0x00, 0x00);
        }
        //��Ȧ����
        public byte[] CameraIrisSwitch(uint deviceAddress, Iris action)
        {
            return Message.GetMessage(deviceAddress, (byte)action, 0x00, 0x00, 0x00);
        }
        //�۽�����
        public byte[] CameraFocus(uint deviceAddress, Focus action)
        {
            if (action == Focus.Near)
                return Message.GetMessage(deviceAddress, (byte)action, 0x00, 0x00, 0x00);
            else
                return Message.GetMessage(deviceAddress, 0x00, (byte)action, 0x00, 0x00);
        }
        //�Խ�����
        public byte[] CameraZoom(uint deviceAddress, Zoom action)
        {
            return Message.GetMessage(deviceAddress, 0x00, (byte)action, 0x00, 0x00);
        }
        //���¿���
        public byte[] CameraTilt(uint deviceAddress, Tilt action, uint speed)
        {
            if (speed < TiltSpeedMin)
                speed = TiltSpeedMin;
            if (speed < TiltSpeedMax)
                speed = TiltSpeedMax;
            return Message.GetMessage(deviceAddress, 0x00, (byte)action, 0x00, (byte)speed);
        }
        //���ҿ���
        public byte[] CameraPan(uint deviceAddress, Pan action, uint speed)
        {
            if (speed < PanSpeedMin)
                speed = PanSpeedMin;
            if (speed < PanSpeedMax)
                speed = PanSpeedMax; 
            return Message.GetMessage(deviceAddress, 0x00, (byte)action, (byte)speed, 0x00);
        }
        //ֹͣ��̨���ƶ�
        public byte[] CameraStop(uint deviceAddress)
        {
            return Message.GetMessage(deviceAddress, 0x00, 0x00, 0x00, 0x00);
        }
        //�Զ����ֶ�����
        public byte[] CameraScan(uint deviceAddress, Scan scan)
        {
            byte m_byte = AutoManualScan;
            if (scan == Scan.Auto)
                m_byte = AutoManualScan + Sense;
            return Message.GetMessage(deviceAddress, m_byte, 0x00, 0x00, 0x00);
        }
        #endregion

        public struct Message
        {
            public static byte Address;
            public static byte CheckSum;
            public static byte Command1, Command2, Data1, Data2;
            public static byte[] GetMessage(uint address, byte command1, byte command2, byte data1, byte data2)
            {
                if (address < 1 & address > 256)
                    throw new Exception("Pelco DЭ��ֻ֧��256�豸");
                Address = Byte.Parse((address).ToString());
                Data1 = data1;
                Data2 = data2;
                Command1 = command1;
                Command2 = command2;
                CheckSum = (byte)( STX ^ Address ^ Command1 ^ Command2 ^ Data1 ^ Data2);
                return new byte[] { STX, Address, Command1, Command2, Data1, Data2, CheckSum };
            }
        }
    }
}
