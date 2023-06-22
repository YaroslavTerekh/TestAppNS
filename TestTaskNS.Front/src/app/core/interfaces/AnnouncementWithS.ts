import { Announcement } from "./Announcement"

export interface AnnoucementWithS {
    id: string,
    title: string,
    description: string,
    authorName: string,
    authorEmail: string,
    createdDate: string,
    similarAnnouncements: Announcement[]
}