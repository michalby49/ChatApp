import { Component, OnInit } from '@angular/core';
import { ChatSignalRService } from '../../services/chat-signalr-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  inboxes: { id: string; name: string }[] = [];
  selectedInboxId: string | null = null;

  constructor(private inboxService: ChatSignalRService) {}

  ngOnInit(): void {
    this.loadInboxes();
  }

  loadInboxes(): void {
    // this.inboxService.getInboxes().subscribe({
    //   next: (data) => (this.inboxes = data),
    //   error: (err) => console.error('Failed to load inboxes', err),
    // });
  }

  selectInbox(inboxId: string): void {
    this.selectedInboxId = inboxId;
  }
}
