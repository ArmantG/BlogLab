export class BlogCommentCreate
{
  constructor(
    public blogCommentId: number,
    public blogId: number,
    public parentBlogCommentId: number,
    public content: string
  ) {}
}
