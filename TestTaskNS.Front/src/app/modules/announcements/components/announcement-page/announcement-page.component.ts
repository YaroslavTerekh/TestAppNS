import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AnnoucementWithS } from 'src/app/core/interfaces/AnnouncementWithS';
import { AnnouncementsService } from 'src/app/core/services/announcements.service';

@Component({
  selector: 'app-announcement-page',
  templateUrl: './announcement-page.component.html',
  styleUrls: ['./announcement-page.component.scss']
})
export class AnnouncementPageComponent implements OnInit {
  public fullAnnouncement!: AnnoucementWithS;
  routeSubscription: any;

  constructor(
    private readonly announcementsService: AnnouncementsService,
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) { }

  ngOnInit(): void {
    this.getData(this.route.snapshot.params['id']);

    this.routeSubscription = this.route.paramMap.subscribe(params => {
      this.getData(this.route.snapshot.params['id']);
    });
  }

  onDelete(id: string): void {
    this.announcementsService.deleteAnnouncement(id)
      .subscribe({
        next: res => {
          this.router.navigate(['']);
        }
      })
  }

  private getData(id: string): void {
    this.announcementsService.getAnnouncement(id)
      .subscribe({
        next: res => {
          this.fullAnnouncement = res;
        }
      });
  }
}
