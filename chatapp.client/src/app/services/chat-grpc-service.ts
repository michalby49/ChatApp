import { Injectable } from '@angular/core';
import { ChatServiceClient } from './generated/chat_pb_service';
import { SendMessageRequest, GetMessagesRequest } from './generated/chat_pb';
import { grpc } from '@improbable-eng/grpc-web';

@Injectable({
  providedIn: 'root'
})
export class ChatgRPCService {
  private client: ChatServiceClient;

  constructor() {
    this.client = new ChatServiceClient('https://localhost:5001');
  }

  public sendMessage(inboxId: string, senderId: string, content: string): void {
    const request = new SendMessageRequest();
    request.setInboxId(inboxId);
    request.setSenderId(senderId);
    request.setContent(content);

    this.client.sendMessage(request, {}, (err, response) => {
      if (err) {
        console.error('Error:', err);
      } else {
        console.log('Message sent:', response.getSuccess());
      }
    });
  }

  public getMessages(inboxId: string): void {
    const request = new GetMessagesRequest();
    request.setInboxId(inboxId);

    this.client.getMessages(request, {}, (err, response) => {
      if (err) {
        console.error('Error:', err);
      } else {
        response.getMessagesList().forEach(msg => {
          console.log(`Message from ${msg.getSenderId()}: ${msg.getContent()}`);
        });
      }
    });
  }
}
