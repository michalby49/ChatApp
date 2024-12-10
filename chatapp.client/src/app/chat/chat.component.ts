import { Component } from '@angular/core';
import { ChatSignalRService } from '../services/chat-signalr-service';
import { BehaviorSubject, Observable } from 'rxjs';
import { ChatgRPCService } from '../services/chat-grpc-service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  user = '';
  message = '';

  get messages$(): Observable<{ user: string, message: string }[]>{
    return this.chatSignalRService.messages$;
  }

  constructor(
    private chatSignalRService: ChatSignalRService,
    private chatgrpcService: ChatgRPCService) {}

  sendMessage(): void {
    if (this.user && this.message) {
      this.chatSignalRService.sendMessage(this.user, this.message);
      this.message = '';
    }

    if (this.user && this.message) {
      this.chatgrpcService.sendMessage("0", "0", this.message);
      this.message = '';
    }
  }
}
