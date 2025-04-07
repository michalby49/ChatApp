import { Component, OnInit } from '@angular/core';
import { ChatSignalRService } from '../../../../services/chat-signalr-service';
import { CoreService } from '../../../../services/core.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users: any[] = []; // Pełna lista użytkowników
  filter: string = ''; // Filtr tekstowy
  filteredUsers: any[] = []; // Filtrowani użytkownicy

  constructor(private coreService: CoreService) {}

  ngOnInit(): void {
    this.coreService.getAllUsers().subscribe({
      next: (response) => {
        this.users = response;
        this.filteredUsers = this.users;
      },
      error: (err) => console.error('Błąd podczas pobierania użytkowników:', err),
    });
  }

  onUserClick(user: any): void {
    this.coreService.createInbox(user.username).subscribe({
      next: (response) => {
        alert('Inbox został otworzony lub utworzony!');
        console.log('Inbox created or opened:', response);
      },
      error: (err) => {
        alert('Nie udało się utworzyć lub otworzyć inboxa.');
        console.error(err);
      },
    });
  }

  ngOnChanges(): void {
    this.filteredUsers = this.filter
      ? this.users.filter((user) =>
          user.username.toLowerCase().includes(this.filter.toLowerCase())
        )
      : this.users;
  }
}
