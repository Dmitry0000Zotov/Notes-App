import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { INote } from 'src/app/models/note';
import { INotice } from 'src/app/models/notice';
import { ITag } from 'src/app/models/tag';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private httpClient: HttpClient) { }

  getTags() {
    return this.httpClient.get<ITag[]>('https://localhost:7191/notes/tag/getTagList');
  }

  createTag(tag: ITag) {
    const postData = { title: tag.title};
    return this.httpClient.post<ITag>('https://localhost:7191/notes/tag/createTag', postData);
  }

  deleteTag(tagId: string) {
    const params = new HttpParams().set('id', tagId);
    return this.httpClient.delete<any>('https://localhost:7191/notes/tag/deleteTag', {params: params});
  }

  bindTagsToNote(note: INote) {
    let tagsId: string[] = note.tags.map(tag => tag.tagId);
    const bindData = { noteId: note.noteId, tags: tagsId};
    return this.httpClient.put<void>('https://localhost:7191/notes/tag/bindTagToNote', bindData);
  }

  bindTagsToNotice(notice: INotice) {
    let tagsId: string[] = notice.tags.map(tag => tag.tagId);
    const bindData = { noticeId: notice.noticeId, tags: tagsId };
    return this.httpClient.put<void>('https://localhost:7191/notes/tag/bindTagToNotice', bindData);
  }
}
