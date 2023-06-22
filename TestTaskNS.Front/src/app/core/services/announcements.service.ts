import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Announcement } from '../interfaces/Announcement';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AnnoucementWithS } from '../interfaces/AnnouncementWithS';
import { ModifyAnnouncementRequest } from '../requests/ModifyAnnouncementRequest';
import { CreateNewAnnouncementRequest } from '../requests/CreateNewAnnouncementRequest';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementsService {

  constructor(
    private readonly http: HttpClient
  ) { }
  
  public getAllAnnouncements(): Observable<Announcement[]> {
    return this.http.get<Announcement[]>(`${environment.apiAddress}announcements/get`);
  }

  public getAnnouncement(id: string): Observable<AnnoucementWithS> {
    return this.http.get<AnnoucementWithS>(`${environment.apiAddress}announcements/get/${id}`);
  }

  public addAnnouncement(request: CreateNewAnnouncementRequest): Observable<any> {
    return this.http.post(`${environment.apiAddress}announcements/add`, request);
  }

  public modifyAnnouncement(request: ModifyAnnouncementRequest): Observable<any> {
    return this.http.put(`${environment.apiAddress}announcements/modify`, request);
  }

  public deleteAnnouncement(id: string): Observable<any> {
    return this.http.delete(`${environment.apiAddress}announcements/${id}`);
  }
}
