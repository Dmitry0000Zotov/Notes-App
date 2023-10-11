import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { INote } from 'src/app/models/note';
import { TagService } from '../tags/tag.service';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private httpClient: HttpClient, private tagService: TagService) { }

  getNotes() {
    return this.httpClient.get<INote[]>('https://localhost:7191/notes/note/getNoteList');
  }

  getNote(noteId: string) {
    const params = new HttpParams().set('id', noteId);
    return this.httpClient.get<INote>('https://localhost:7191/notes/note/getNote', {params: params})
  }

  createNote(note: INote) {
    const postData = { title: note.title, details: note.details, dateNote: note.dateNote};
    return this.httpClient.post<INote>('https://localhost:7191/notes/note/createNote', postData);
  }

  deleteNote(noteId: string) {
    const params = new HttpParams().set('id', noteId);
    return this.httpClient.delete<any>('https://localhost:7191/notes/note/deleteNote', {params: params});
  }

  updateNote(updatedNote: INote) {
    const updatedData = { noteId: updatedNote.noteId, title: updatedNote.title, details: updatedNote.details, dateNote: updatedNote.dateNote };
    return this.httpClient.put<INote>('https://localhost:7191/notes/note/updateNote', updatedData);
  }


}
