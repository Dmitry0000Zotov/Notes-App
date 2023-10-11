import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { INotice } from 'src/app/models/notice';

@Injectable({
  providedIn: 'root'
})
export class NoticeService {

  constructor(private httpClient: HttpClient) { }

  getNotices() {
    return this.httpClient.get<INotice[]>('https://localhost:7191/notes/notice/getNoticeList');
  }

  createNotice(notice: INotice) {
    const postData = { title: notice.title, deadline: notice.deadline};
    return this.httpClient.post<INotice>('https://localhost:7191/notes/notice/createNotice', postData);
  }

  updateNotice(updatedNotice: INotice) {
    const updatedData = { noticeId: updatedNotice.noticeId, title: updatedNotice.title, deadline: updatedNotice.deadline };
    return this.httpClient.put<INotice>('https://localhost:7191/notes/notice/updateNotice', updatedData);
  }

  deleteNotice(noticeId: string) {
    const params = new HttpParams().set('id', noticeId);
    return this.httpClient.delete<any>('https://localhost:7191/notes/notice/deleteNotice', {params: params});
  }
}
