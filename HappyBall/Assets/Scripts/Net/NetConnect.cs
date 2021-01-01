using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;
using Google.Protobuf;






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
