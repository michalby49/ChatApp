import { Component, Input, OnChanges } from '@angular/core';
import { ChatSignalRService } from '../../../services/chat-signalr-service';
import { BehaviorSubject, Observable } from 'rxjs';
import { ChatgRPCService } from '../../../services/chat-grpc-service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnChanges {
  @Input() selectedInboxId: string | null = null;
  message: string = "";
  messages: string[] = [];

  get messages$(): Observable<{ user: string, message: string }[]>{
    return this.chatSignalRService.messages$;
  }

  constructor(
    private chatSignalRService: ChatSignalRService,
    private chatgrpcService: ChatgRPCService) {}

    ngOnChanges(): void {
      if (this.selectedInboxId) {
        this.loadMessages();
      }
    }

    loadMessages(): void {
      console.log('Loading messages for inbox:', this.selectedInboxId);
      // Tutaj załaduj wiadomości z API dla wybranego inboxa
    }

  sendMessage(): void {
    if (this.message && this.selectedInboxId) {
      this.chatSignalRService.sendMessage(this.message, this.selectedInboxId);
      this.message = '';
    }

    if (this.message) {
      //this.chatgrpcService.sendMessage("0", "0", this.message);
      this.message = '';
    }
  }
}
