import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnnouncementPageComponent } from './modules/announcements/components/announcement-page/announcement-page.component';
import { AnnouncementComponent } from './modules/announcements/components/announcement/announcement.component';
import { ModifyComponent } from './modules/announcements/components/modify/modify.component';

const routes: Routes = [
  { path: "", component: AnnouncementComponent },
  { path: "announcement/:id", component: AnnouncementPageComponent },
  { path: "modify/:id", component: ModifyComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
