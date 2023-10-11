import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { INote } from 'src/app/models/note';
import { NoteService } from 'src/app/services/notes/note.service';
import { DialogBoxComponent } from '../../UI/dialog-box/dialog-box.component';
import { DeleteDialogBoxComponent } from '../../UI/delete-dialog-box/delete-dialog-box.component';
import { TagService } from 'src/app/services/tags/tag.service';

@Component({
  selector: 'app-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrls: ['./notes-list.component.scss'],
})
export class NotesListComponent implements OnInit, OnDestroy{
  notes: INote[];
  selectedNote: INote;
  notesSubscription: Subscription;

  constructor(private noteService: NoteService, private tagService: TagService, public dialog: MatDialog) {

  }

  showNoteDetails (note : INote) {
    this.selectedNote = note;
  }

  openDialog(): void {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.disableClose = true;

    const dialogRef = this.dialog.open(DialogBoxComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((data) => {
      if(data) this.createNewNote(data);
    });
  }

  openDeleteDialog(noteId: string, type: string) {
    let deleteDialogConfig = new MatDialogConfig();
    deleteDialogConfig.disableClose = true;
    deleteDialogConfig.data = { id: noteId, type: type };

    const deleteDialogRef = this.dialog.open(DeleteDialogBoxComponent, deleteDialogConfig);
    
    deleteDialogRef.afterClosed().subscribe((data) => {
      if(data) this.deleteItem(data);
    });
  }

  createNewNote(inputData: INote) {
    console.log(inputData);
    this.noteService.createNote(inputData).subscribe((data)=>
    {
      if(inputData.tags){
        inputData.noteId = data.noteId;
        this.tagService.bindTagsToNote(inputData).subscribe();
        data.tags = inputData.tags;
      }
      console.log(data);
      this.notes.push(data);
    });
  }
  
  deleteItem(noteId: string) {
    this.noteService.deleteNote(noteId).subscribe(()=> {
      const foundItem = this.notes.find(item => item.noteId === noteId);
      if (foundItem) {
        const idx = this.notes.findIndex(item => item.noteId === noteId);
        this.notes.splice(idx, 1);
      }
      this.selectedNote.noteId = '';
    });
  }

  ngOnInit(): void {
    this.notesSubscription = this.noteService.getNotes().subscribe((data)=>{
      this.notes = data;
    });  
  }
  
  ngOnDestroy() {
    if(this.notesSubscription) this.notesSubscription.unsubscribe();
  }

}
