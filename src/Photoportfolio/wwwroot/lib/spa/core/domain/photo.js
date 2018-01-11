"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Photo = (function () {
    function Photo(id, title, uri, albumId, albumTitle, author, rating, dateUploaded) {
        this.Id = id;
        this.Title = title;
        this.Uri = uri;
        this.AlbumId = albumId;
        this.AlbumTitle = albumTitle;
        this.Author = author;
        this.Rating = rating;
        this.DateUploaded = dateUploaded;
    }
    return Photo;
}());
exports.Photo = Photo;
