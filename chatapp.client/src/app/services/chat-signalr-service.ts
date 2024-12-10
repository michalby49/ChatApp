import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatSignalRService {
  private hubConnection: signalR.HubConnection;
  private messages = new BehaviorSubject<{ user: string, message: string }[]>([]);
  messages$ = this.messages.asObservable();

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7188/chathub')
      .withAutomaticReconnect()
      .build();

    this.startConnection()

    this.hubConnection.on('ReceiveMessage', (user: string, message: string) => {
      const currentMessages = this.messages.value;
      this.messages.next([...currentMessages, { user, message }]);
    });

    this.hubConnection.onreconnected(() => {
      console.log('Reconnected to the hub');
    });

    this.hubConnection.onclose(() => {
      console.error('Connection closed, attempting to reconnect...');
      setTimeout(() => this.startConnection(), 5000);
    });
  }

  private startConnection(): void {
    this.hubConnection.start().then(() => {
      console.log('Hub connection started');
    }).catch(err => {
      console.error('Error while starting connection: ' + err);
      setTimeout(() => this.startConnection(), 5000);
    });
  }

  sendMessage(user: string, message: string): void {
    if (this.hubConnection.state === signalR.HubConnectionState.Connected) {
      this.hubConnection.send('SendMessage', user, message)
        .catch(err => console.error('Error while sending message: ' + err));
    } else {
      console.error('Cannot send message: Hub connection is not in the Connected state');
    }
  }
}
