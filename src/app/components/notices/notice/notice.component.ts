import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { INotice } from 'src/app/models/notice';
import { NoticeService } from 'src/app/services/notices/notice.service';
import { NoticeDialogBoxComponent } from '../../UI/notice-dialog-box/notice-dialog-box.component';
import { DeleteDialogBoxComponent } from '../../UI/delete-dialog-box/delete-dialog-box.component';
import { TagService } from 'src/app/services/tags/tag.service';

@Component({
  selector: 'app-notice',
  templateUrl: './notice.component.html',
  styleUrls: ['./notice.component.scss']
})
export class NoticeComponent implements OnInit, OnDestroy{
  constructor(private noticeService: NoticeService, private tagService: TagService, public dialog: MatDialog) {}

  notices: INotice[];
  noticeSubscription: Subscription;


  createNewNotice(inputData: INotice) {
    this.noticeService.createNotice(inputData).subscribe((data)=>
    {
      if(inputData.tags){
        inputData.noticeId = data.noticeId;
        this.tagService.bindTagsToNotice(inputData).subscribe();
        data.tags = inputData.tags;
      }
      this.notices.push(data);
    });
  }

  deleteItem(noticeId: string) {
    this.noticeService.deleteNotice(noticeId).subscribe(()=> {
      const foundItem = this.notices.find(item => item.noticeId === noticeId);
      if (foundItem) {
        const idx = this.notices.findIndex(item => item.noticeId === noticeId);
        this.notices.splice(idx, 1);
      }
    });
  }

  updateData(updatedNotice: INotice) {
    this.noticeService.updateNotice(updatedNotice).subscribe((data)=>
    {
      if(updatedNotice.tags){
        updatedNotice.noticeId = data.noticeId;
        this.tagService.bindTagsToNotice(updatedNotice).subscribe();
        data.tags = updatedNotice.tags;
      }
      let foundItem = this.notices.find(item=>item.noticeId === data.noticeId);
      if (foundItem) {
        const idx = this.notices.findIndex(item => item.noticeId === data.noticeId);
        this.notices[idx] = data;
      }
    });
  }

  openEditDialog(notice: INotice): void {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.disableClose = true;
    dialogConfig.data = notice;

    const dialogRef = this.dialog.open(NoticeDialogBoxComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((data) => {
      if(data && data.noticeId) this.updateData(data);
    });
  }

  openDeleteDialog(noticeId: string, type: string) {
    let deleteDialogConfig = new MatDialogConfig();
    deleteDialogConfig.disableClose = true;
    deleteDialogConfig.data = { id: noticeId };

    const deleteDialogRef = this.dialog.open(DeleteDialogBoxComponent, deleteDialogConfig);
    
    deleteDialogRef.afterClosed().subscribe((data) => {
      if(data) this.deleteItem(data);
    });
  }

  openCreateNoticeDialog(): void {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.disableClose = true;

    const dialogRef = this.dialog.open(NoticeDialogBoxComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((data) => {
      if(data) this.createNewNotice(data);
    });
  }


  ngOnInit(): void {
    this.noticeSubscription = this.noticeService.getNotices().subscribe((data)=>{
      this.notices = data;
    });  
  }
  
  ngOnDestroy() {
    if(this.noticeSubscription) this.noticeSubscription.unsubscribe();
  }
}
