using System.Collections;
using System.Collections.Generic;
using FlatBuffers;
using RootNamespace;
using UnityEngine;

public class FlatbuffersTest : MonoBehaviour
{
    private byte[] _data;
    private int _globalValue;
    private ByteArrayAllocator _allocator;
    private ByteBuffer _byteBuffer;
    
    private byte[] CreateBuffer()
    {
        FlatBufferBuilder builder = new FlatBufferBuilder(1024);

        int intValue = 5;
        StringOffset stringValue = builder.CreateString("someName");

        Offset<SimpleType> obj = SimpleType.CreateSimpleType(builder, intValue, stringValue);
        builder.Finish(obj.Value);
        byte[] data = builder.SizedByteArray();
        return data;
    }

    public void WarmUp()
    {
        _data = CreateBuffer();
        _allocator = new ByteArrayAllocator();
        _byteBuffer = new ByteBuffer();
    }

    private void Deserialize()
    {
        _allocator.Reuse(_data);
        _byteBuffer.Reuse(_allocator, 0);
        
        SimpleType simpleType = SimpleType.GetRootAsSimpleType(_byteBuffer);
        _globalValue += simpleType.IntValue;
    }
    
    public void Run()
    {
        Debug.Log($"Before: {_globalValue}");
        
        for (int i = 0; i < 100000; i++)
        {
            Deserialize();
        }
        
        Debug.Log($"After: {_globalValue}");
    }
}
