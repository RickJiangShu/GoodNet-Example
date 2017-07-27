/*
 * Author:  Rick
 * Create:  2017/7/27 10:53:19
 * Email:   rickjiangshu@gmail.com
 * Follow:  https://github.com/RickJiangShu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtocolZ;

/// <summary>
/// BehaviourScript1
/// </summary>
public class Test : MonoBehaviour
{
    public ProtobufSocket socket;
    // Use this for initialization
    void Start()
    {
        socket.Listen<pto_S2C_ResLogin>((uint)LoginProtocolID.S2C_ResLogin, OnResLogin);
    }

    public void OnDestroy()
    {
        socket.Unlisten<pto_S2C_ResLogin>((uint)LoginProtocolID.S2C_ResLogin, OnResLogin);
    }


    private void OnResLogin(pto_S2C_ResLogin resLogin)
    {
        print(resLogin);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pto_C2S_ReqLogin req = new pto_C2S_ReqLogin();
            req.player_id = 123;
            socket.Send((uint)LoginProtocolID.C2S_ReqLogin, req);
        }
    }
}
