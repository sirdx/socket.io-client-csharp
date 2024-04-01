using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using MessagePack.Resolvers;
using SocketIO.Serializer.MessagePack;
using SocketIO.Serializer.SystemTextJson;

namespace SocketIO.Client.IntegrationTests.Utils;

public static class SerializerHelper
{
    public static void SetMessagePackSerializer(this SocketIOClient io)
    {
        io.Serializer = new SocketIOMessagePackSerializer(ContractlessStandardResolver.Options);
    }
    
    public static void ConfigureSystemTextJsonSerializer(this SocketIOClient io, JsonSerializerOptions options)
    {
        io.Serializer = new SystemTextJsonSerializer(options);
    }
    
    public static void ConfigureSystemTextJsonSerializerForEmitting1Parameter(this SocketIOClient io)
    {
        io.ConfigureSystemTextJsonSerializer(new JsonSerializerOptions
        {
            // https://learn.microsoft.com/zh-cn/dotnet/api/system.text.unicode.unicoderanges?view=net-8.0
            // Currently, the UnicodeRange class supports only named ranges in the Basic Multilingual Plane (BMP)
            // which extends from U+0000 to U+FFFF.
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs)
        });
    }
}