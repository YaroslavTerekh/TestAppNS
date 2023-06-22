import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AnnouncementsRoutingModule } from './announcements-routing.module';
import { AnnoucementItemComponent } from './components/annoucement-item/annoucement-item.component';
import { AnnouncementPageComponent } from './components/announcement-page/announcement-page.component';
import { AnnouncementComponent } from './components/announcement/announcement.component';
import { ModifyComponent } from './components/modify/modify.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AnnouncementComponent,
    AnnouncementPageComponent,
    AnnoucementItemComponent,
    ModifyComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AnnouncementsRoutingModule
  ]
})
export class AnnouncementsModule { }
