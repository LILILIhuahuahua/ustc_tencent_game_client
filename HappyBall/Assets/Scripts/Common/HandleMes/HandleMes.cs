using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//HandleMes脚本用来及进行消息的转发
class HandleMes 
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //消息转发
    public static void transmitMes(GMessage gMessage)
    {
        MSG_TYPE msgType = gMessage.MsgType;
        switch (msgType)
        {
            case MSG_TYPE.Notify:
                Debug.Log("NotifyType");
                HandleNotifyMes.HandNotifyMessage(gMessage.Notify);
                break;
            case MSG_TYPE.Request:
                Debug.Log("RequestType");

                break;
            case MSG_TYPE.Response:
                Debug.Log("RequestType");
                break;
            default:
                Debug.Log("接受到错误的消息类型");
                break;
        }
    }

    
}
