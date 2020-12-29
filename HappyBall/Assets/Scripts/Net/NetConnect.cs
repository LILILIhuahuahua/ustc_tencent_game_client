using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;
//using HappyBallProto;
using SocketGameProtocol;
using Google.Protobuf;
using HappyBallProto;
//using Google.Protobuf; //导入的Google引用用来序列化与反序列化




public class NetConnect : MonoBehaviour {

    // Use this for initialization
    public Socket socket;
    private byte[] receiveBuffer = new byte[1024];
    private byte[] snedBuffer = new byte[1024];

    // Use this for initialization

    //单例模式，其他脚本方便获得client
    private static Socket _socket;
    public static Socket Socket
    {
        get
        {
            return _socket;
        }
    }

    void Start()
    {
        /* socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         socket.Connect("127.0.0.1", 8889); //客户端连接服务器
         StartReceive();

         //设置单例
         _socket = socket;


         //测试用
         Send("Hello i am client");*/

        //测试用
        //1.声明
        GMessage gMessage = new GMessage();
        Notify notify = new Notify();
        PlayerMsg playerMesg = new PlayerMsg();
        CoordinateXY pos = new CoordinateXY();
        EntityInfoChangeNotify entityInfoChangeNotify = new EntityInfoChangeNotify();
       
        gMessage.MsgType = 1;
        gMessage.SeqId = 2;
        //2.写数据
        entityInfoChangeNotify.EntityType = Message.PlyerType; //玩家
        entityInfoChangeNotify.EntityId = 8080;

        playerMesg.PlayerId = 8080;
        
        pos.CoordinateX = 120;
        pos.CoordinateY = 200;

        //3.填包
        playerMesg.PlayerPosition = pos;
        entityInfoChangeNotify.PlayerMsg = playerMesg;
        notify.EntityInfoChangeNotify = entityInfoChangeNotify;
        gMessage.Notify = notify;

        //4.测试
        HandleMes.transmitMes(gMessage);
    }


    //后期接受到的包需要进行解包、再转发
    void StartReceive()
    {
        socket.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
        //byte转为string
        string str = Encoding.UTF8.GetString(receiveBuffer);
        int x = int.Parse(str);
        Debug.Log(str);

        //继续接受
        StartReceive();
    }

    //后期发送的类型需要是：包
    void Send(string data)
    {
        try
        {
            //Test
            //GMessage gMessage = new GMessage();
            //gMessage.MsgType = 1;
            //gMessage.SeqId = 2;
            //Notify notify = new Notify();
            //gMessage.Notify = notify;
            //HandleMes.transmitMes(gMessage);



            //使用ProtoBuf工具的序列化方法
            //Serializer.Serialize<data>(fs, da);//把user对象序列化出二进制文件放入fs文件里面
            //ProtoBuf.Serializer.Serialize<NetModel>(ms, model);

            int len = socket.Send(Encoding.UTF8.GetBytes(data));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
