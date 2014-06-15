using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Tao.OpenGl;
using UnityEngine;

public class Check_ScreenShot : MonoBehaviour {
	private Texture2D tex;
	private List <Texture2D> tex2;
	private int k = 0;
	
	// Use this for initialization
	void Start () {
		tex2 = new List<Texture2D>();
		//tex2[i] = Resources.Load("screenshot")  as Texture2D;
        for (int j = 0; ; j++)
        {
            var path = "Assets/Resources/screenshot" + j + ".png";
            if (!File.Exists(path))
                break;

            var ptr = GetPtr(path);
            var texture = Texture2D.CreateExternalTexture(Screen.width, Screen.height, TextureFormat.ARGB32, false, false, ptr);//Resources.Load("screenshot" + j)  as Texture2D;
			if(texture != null){
				tex2.Add(texture);
			}
			else{
				break;
			}
		}
		tex = tex2[0];
		Shader.SetGlobalTexture("_Photo", tex);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("c")){
			tex = tex2[k];
			Shader.SetGlobalTexture("_Photo", tex);
			k = (k + 1)%tex2.Count;
		}
		if(Input.GetKeyDown("g")){
			Application.LoadLevel("collection");
		}
	}

    IntPtr GetPtr(string fileName)
    {
        var bitmap = new Bitmap(fileName);
        bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
        var data = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        var bytes = new byte[bitmap.Width * bitmap.Height * 4];
        System.Runtime.InteropServices.Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        bitmap.UnlockBits(data);

        byte r, b;
        int n;

        for (int i = 0; i < bitmap.Width * bitmap.Height; ++i)
        {
            n = i * 4;
            b = bytes[n];
            r = bytes[n + 2];

            bytes[n] = r;
            bytes[n + 2] = b;
        }

        var name = new uint[1]; ;
        Gl.glGenTextures(1, name);
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, name[0]);
        Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
        Gl.glTexImage2D(
                    Gl.GL_TEXTURE_2D,
                    0,
                    4,
                    bitmap.Width, bitmap.Height,
                    0,
                    Gl.GL_RGBA,
                    Gl.GL_UNSIGNED_BYTE,
                    bytes
                );

        Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
        Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

        Gl.glBindTexture(Gl.GL_TEXTURE_2D, name[0]);

        IntPtr ptr = IntPtr.Zero;
        Gl.glGetTexImage(Gl.GL_TEXTURE_2D, 0, Gl.GL_DEPTH_COMPONENT, Gl.GL_UNSIGNED_BYTE, ptr);
        
        return data.Scan0;
    }
}
