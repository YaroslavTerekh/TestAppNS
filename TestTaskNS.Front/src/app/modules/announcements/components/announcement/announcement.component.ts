import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Announcement } from 'src/app/core/interfaces/Announcement';
import { AnnouncementsService } from 'src/app/core/services/announcements.service';
import { CreateNewAnnouncementRequest } from 'src/app/core/requests/CreateNewAnnouncementRequest';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.scss']
})
export class AnnouncementComponent implements OnInit {
  public announcements!: Announcement[];
  public errorList: string[] = [];
  public addForm: FormGroup = this.fb.group({
    title: this.fb.control(''),
    description: this.fb.control(''),
    authorEmail: this.fb.control(''),
    authorName: this.fb.control('')
  })

  constructor(
    private readonly announcementsService: AnnouncementsService,
    private readonly fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.announcementsService.getAllAnnouncements()
      .subscribe({
        next: res => {
          this.announcements = res;
        }
      });
  }

  onCreateNewAnnouncement(): void {
    const request: CreateNewAnnouncementRequest = {
      title: this.addForm.get('title')!.value,
      description: this.addForm.get('description')!.value,
      authorEmail: this.addForm.get('authorEmail')!.value,
      authorName: this.addForm.get('authorName')!.value,
    }

    this.announcementsService.addAnnouncement(request)
      .subscribe({
        next: res => {
          this.announcementsService.getAllAnnouncements()
            .subscribe({
              next: res => {
                this.announcements = res;
              }
            });
          
          this.addForm = this.fb.group({
            title: this.fb.control(''),
            description: this.fb.control(''),
            authorEmail: this.fb.control(''),
            authorName: this.fb.control('')
          });
        },
        error: err => {
          this.errorList = err.error.error;
        }
      })
  }

}
