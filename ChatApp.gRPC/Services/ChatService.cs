using Grpc.Core;
using ChatApp.gRPC;

public class ChatService : ChatApp.gRPC.ChatService.ChatServiceBase
{
    public ChatService()
    {
    }

    public override async Task<GetMessagesResponse> GetMessages(GetMessagesRequest request, ServerCallContext context)
    {
        var response = new GetMessagesResponse();

        return response;
    }

    public override async Task<SendMessageResponse> SendMessage(SendMessageRequest request, ServerCallContext context)
    {
        return new SendMessageResponse { Success = true };
    }
}