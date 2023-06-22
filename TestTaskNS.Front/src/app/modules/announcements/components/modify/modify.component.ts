import { ModifyAnnouncementRequest } from './../../../../core/requests/ModifyAnnouncementRequest';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AnnoucementWithS } from 'src/app/core/interfaces/AnnouncementWithS';
import { AnnouncementsService } from 'src/app/core/services/announcements.service';

@Component({
  selector: 'app-modify',
  templateUrl: './modify.component.html',
  styleUrls: ['./modify.component.scss']
})
export class ModifyComponent implements OnInit {
  public errorList: string[] = [];
  public announcement!: AnnoucementWithS;
  public modifyForm: FormGroup = this.fb.group({
    title: this.fb.control(''),
    description: this.fb.control(''),
    email: this.fb.control('')
  });

  constructor(
    private readonly announcementsService: AnnouncementsService,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.announcementsService.getAnnouncement(this.route.snapshot.params['id'])
      .subscribe({
        next: res => {
          this.announcement = res;

          this.modifyForm = this.fb.group({
            title: this.fb.control(res.title),
            description: this.fb.control(res.description),
            email: this.fb.control(res.authorEmail)
          })
        }
      });
  }

  onModify(): void {
    const request: ModifyAnnouncementRequest = {
      id: this.announcement.id,
      title: this.modifyForm.get('title')!.value,
      description: this.modifyForm.get('description')!.value,
      authorEmail: this.modifyForm.get('email')!.value,
    };

    this.announcementsService.modifyAnnouncement(request)
      .subscribe({
        next: res => {
          this.router.navigate(['']);
        },
        error: err => {
          this.errorList = err.error.error;
        }
      })
  }
}