export interface INotice {
    noticeId: string
    title: string 
    deadline: Date
    dateCreation: Date
    dateEdit: Date
    tags: Array<any> 
}