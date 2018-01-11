export class Photo {
    Id: number;
    Title: string;
    Uri: string;
    AlbumId: number;
    AlbumTitle: string;
    Author: string;
    Rating: number;
    RatingWidthPersentage: number;
    DateUploaded: Date

    constructor(id: number,
        title: string,
        uri: string,
        albumId: number,
        albumTitle: string,
        author: string,
        rating: number,
        dateUploaded: Date) {
        this.Id = id;
        this.Title = title;
        this.Uri = uri;
        this.AlbumId = albumId;
        this.AlbumTitle = albumTitle;
        this.Author = author;
        this.Rating = rating;
        this.DateUploaded = dateUploaded;
    }
}