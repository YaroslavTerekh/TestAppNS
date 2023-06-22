import { Component, Input, OnInit } from '@angular/core';
import { Announcement } from 'src/app/core/interfaces/Announcement';
import { AnnoucementWithS } from 'src/app/core/interfaces/AnnouncementWithS';
import { AnnouncementsService } from 'src/app/core/services/announcements.service';

@Component({
  selector: 'app-annoucement-item',
  templateUrl: './annoucement-item.component.html',
  styleUrls: ['./annoucement-item.component.scss']
})
export class AnnoucementItemComponent implements OnInit {
  @Input()
  public announcement!: Announcement;

  constructor() { }

  ngOnInit(): void {

  }

}
