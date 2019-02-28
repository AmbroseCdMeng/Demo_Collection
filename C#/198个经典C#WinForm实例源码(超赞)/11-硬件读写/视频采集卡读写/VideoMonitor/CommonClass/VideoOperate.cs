using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VideoMonitor.CommonClass
{
    class VideoOperate
    {
        #region  ��Ƶ�ɼ����е�ö��

        public enum DISPLAYTRANSTYPE
        {
            NOT_DISPLAY = 0,
            PCI_VIEDOMEMORY = 1,
            PCI_MEMORY_VIDEOMEMORY = 2
        }

        //��ƵԤ������Ƶ��׽��������ʽ��Ŀǰ�汾ֻ֧��UUY2��ʽ
        public enum COLORFORMAT
        {
            RGB32 = 0x0,
            RGB24 = 0x1,
            RGB16 = 0x2,
            RGB15 = 0x3,
            YUY2 = 0x4,
            BTYUV = 0x5,
            Y8 = 0x6,
            RGB8 = 0x7,
            PL422 = 0x8,
            PL411 = 0x9,
            YUV12 = 0xA,
            YUV9 = 0xB,
            RAW = 0xE
        }

        /*��ƵԤ������Ƶ�������ʾ���ԣ����У�
            BRIGHTNESSΪ���ȣ�value��Χ��0~255����ѣ�80
            CONTRASTΪ�Աȶȣ�value��Χ��-128~127����ѣ�0x44
            SATURATIONΪ���Ͷȣ�value��Χ��-128~127����ѣ�0x40
            HUEΪɫ�ȣ�value��Χ��-128~127����ѣ�0x0
                ֻ�е�COLORDEVICETYPE����COLOR_DECODERʱ����Ч
            SHARPNESSΪ��ȣ�value��Χ��-8~7����ѣ�0x0
                ֻ�е�COLORDEVICETYPE����COLOR_DECODERʱ����Ч
        */
        public enum COLORCONTROL
        {
            BRIGHTNESS = 0,
            CONTRAST = 1,
            SATURATION = 2,
            HUE = 3,
            SHARPNESS = 4
        }

        /*��ʾ�豸����ʾ���ԣ����У�
            COLOR_DECODERΪ����������ʾ���ԣ�����Ӱ����ƵԤ������Ƶ�������ʾ����
            COLOR_PREVIEWΪ��ƵԤ������ʾ����
            COLOR_CAPTUREΪ��Ƶ�������ʾ����
        */
        public enum COLORDEVICETYPE
        {
            COLOR_DECODER = 0,
            COLOR_PREVIEW = 1,
            COLOR_CAPTURE = 2,
        }

        /*����Ƶ����ʽ�����У�
            CAP_NULL_STREAM ������Ч
            CAP_ORIGIN_STREAM ����Ϊԭʼ���ص�
            CAP_MPEG4_STREAM ����ΪMPEG4
        */
        public enum CAPMODEL
        {
            CAP_NULL_STREAM = 0,
            CAP_ORIGIN_STREAM = 1,
            CAP_MPEG4_STREAM = 2,
        }

        /*����ƵMPEG4����ʽ��ֻ��CAPMODEL����CAP_MPEG4_STREAMʱ��Ч�����У�
           MPEG4_AVIFILE_ONLY ��ΪMPEG4�ļ�
           MPEG4_CALLBACK_ONLY MPEG���ݻص�
           MPEG4_AVIFILE_CALLBACK ��ΪMPEG�ļ����ص�
       */
        public enum MP4MODEL
        {
            MPEG4_AVIFILE_ONLY = 0,
            MPEG4_CALLBACK_ONLY = 1,
            MPEG4_AVIFILE_CALLBACK = 2,
        }

        /*MPEG4_XVIDѹ��ģʽ�����У�
           XVID_CBR_MODE 
           XVID_VBR_MODE 
       */
        public enum COMPRESSMODE
        {
            XVID_CBR_MODE = 0,
            XVID_VBR_MODE = 1,
        }

        /*��ƵԴ������Ƶ�ʣ����У�
           FIELD_FREQ_50HZ 50HZ,���Զ���ΪPAL��ʽ
           FIELD_FREQ_60HZ 60HZ,���Զ���ΪNTSC��ʽ
           FIELD_FREQ_0HZ ���ź�
       */
        public enum eFieldFrequency
        {
            FIELD_FREQ_50HZ = 0,
            FIELD_FREQ_60HZ = 1,
            FIELD_FREQ_0HZ = 2,
        }

        /*��ƽ״̬�����У�
           HIGH_VOLTAGE �ߵ�ƽ
           LOW_VOLTAGE �͵�ƽ
       */
        public enum eVOLTAGELEVEL
        {
            HIGH_VOLTAGE = 0,
            LOW_VOLTAGE = 1,
        }

        #endregion

        #region  ��Ƶ�ɼ����е�API����

        //��ʼ��ϵͳ��Դ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAInitSdk")]
        public extern static bool VCAInitSdk(IntPtr hWndMain, DISPLAYTRANSTYPE eDispTransType, bool bLnitAuDev);

        //�ͷ�ϵͳ��Դ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAUnInitSdk")]
        public extern static void VCAUnInitSdk();

        //��ָ�����ŵ��豸��������Ӧϵͳ��Դ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAOpenDevice")]
        public extern static bool VCAOpenDevice(Int32 dwCard, IntPtr hPreviewWnd);

        //�ر�ָ�����ŵ��豸���ͷ���Ӧϵͳ��Դ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCACloseDevice")]
        public extern static bool VCACloseDevice(Int32 dwCard);

        //����ϵͳ���п�����������ΪSAA7134Ӳ����Ŀ��Ϊ0ʱ��ʾû���豸����
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAGetDevNum")]
        public extern static int VCAGetDevNum();

        //��ʼ��ƵԤ��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStartVideoPreview")]
        public extern static bool VCAStartVideoPreview(Int32 dwCard);

        //ֹͣ��ƵԤ��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStopVideoPreview")]
        public extern static bool VCAStopVideoPreview(Int32 dwCard);

        //������ƵԤ��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAUpdateVideoPreview")]
        public extern static bool VCAUpdateVideoPreview(Int32 dwCard, IntPtr hPreviewWnd);

        //����overlay���ڣ���overlay���ھ���ı��ߴ硢λ�øı�ʱ���ã�overlay���ھ��ǰ���
        //��·��ʾС���ڵĴ󴰿ڣ�overlay���ڱ�����һ������·��ʾС���ڱ�����������ڲ�
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAUpdateOverlayWnd")]
        public extern static bool VCAUpdateOverlayWnd(IntPtr hOverlayWnd);

        //�������ΪJPEG�ļ�
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASaveAsJpegFile")]
        public extern static bool VCASaveAsJpegFile(Int32 dwCard, string lpFileName, Int32 dwQuality);

        //�������ΪBMP�ļ�
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASaveAsBmpFile")]
        public extern static bool VCASaveAsBmpFile(Int32 dwCard, string lpFileName);

        //��ʼ��Ƶ����
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStartVideoCapture")]
        public extern static bool VCAStartVideoCapture(Int32 dwCard, CAPMODEL enCapMode, MP4MODEL enMp4Mode, string lpFileName);

        //ֹͣ��Ƶ����
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAStopVideoCapture")]
        public extern static bool VCAStopVideoCapture(Int32 dwCard);

        //������Ƶ����ߴ磬dwWidth��dwHeight���Ϊ16�ı��������򣬶�̬���Ϊ16*16��һ�����С�飬��⽫�᲻׼ȷ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetVidCapSize")]
        public extern static bool VCASetVidCapSize(Int32 dwCard, Int32 dwWidth, Int32 dwHeight);

        //�õ���Ƶ����ߴ�
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAGetVidCapSize")]
        public extern static bool VCAGetVidCapSize(Int32 dwCard, Int32 dwWidth, Int32 dwHeight);

        //������Ƶ����Ƶ��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetVidCapFrameRate")]
        public extern static bool VCASetVidCapFrameRate(Int32 dwCard, Int32 dwFrameRate, bool bFrameRateReduction);

        //����MPEGѹ����λ��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetBitRate")]
        public extern static bool VCASetBitRate(Int32 dwCard, Int32 dwBitRate);

        //����MPEGѹ���Ĺؼ�֡�����������ڵ���֡��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetKeyFrmInterval")]
        public extern static bool VCASetKeyFrmInterval(Int32 dwCard, Int32 dwKeyFrmInterval);

        //����MPEG4_XVIDѹ��������
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetXVIDQuality")]
        public extern static bool VCASetXVIDQuality(Int32 dwCard, Int32 dwQuantizer, Int32 dwMotionPrecision);

        //����MPEG4_XVIDѹ����ģʽ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetXVIDCompressMode")]
        public extern static bool VCASetXVIDCompressMode(Int32 dwCard, COMPRESSMODE enCompessMode);

        //������Ƶ��ɫ���ԣ�����Ӱ����ƵԤ������Ƶ�������ʾ����
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCASetVidDeviceColor")]
        public extern static bool VCASetVidDeviceColor(Int32 dwCard, COLORCONTROL enCtlType, Int32 dwValue);

        //�õ���ƵԴ����Ƶ�ʣ����ɵõ���ƵԴ������ʽ
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAGetVidFieldFrq")]
        public extern static bool VCAGetVidFieldFrq(Int32 dwCard, eFieldFrequency eVidSourceFieldRate);

        //��ʼ����Ƶ�豸������Ƶ����ʾ��ֻ����Ƶ¼�����Ƶ����ʱ����ͨ��VCAInitSdk()�����Ѿ���ʼ����ɣ����Բ���ʼ��
        [DllImport("Sa7134Capture.dll", EntryPoint = "VCAInitVidDev")]
        public extern static bool VCAInitVidDev();

        #endregion
    }
}
