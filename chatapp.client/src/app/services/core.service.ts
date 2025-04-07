import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface CreateInboxRequest
{
  name: string,
  ids: number[]
}

@Injectable({
  providedIn: 'root',
})
export class CoreService {
  private apiUrl = 'https://localhost:7188/api/core';

  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/users`);
  }

  createInbox(request: CreateInboxRequest): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/users`, request);
  }

  getUserInboxes(userId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/inboxes/${userId}`);
  }

  getMessagesByInbox(inboxId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/messages/${inboxId}`);
  }
}
