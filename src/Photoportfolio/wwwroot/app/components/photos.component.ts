import { Component, OnInit } from '@angular/core';
import { Photo } from '../core/domain/photo';
import { Paginated } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';
import { NotificationService } from '../core/services/notification.service';

@Component({
    selector: 'photos',
    templateUrl: './app/components/photos.component.html'
})
export class PhotosComponent extends Paginated implements OnInit {
    private _photosAPI: string = 'api/photos/';
    private _photosVoteApi: string = 'api/photos/vote'
    private _photos: Array<Photo>;

    private totalStars = 5;

    constructor(public photosService: DataService, public notificationService: NotificationService) {
        super(0, 0, 0);
    }

    ngOnInit() {
        this.photosService.set(this._photosAPI, 12);
        this.getPhotos();
    }

    getPhotos(): void {
        let self = this;
        self.photosService.get(self._page)
            .subscribe(res => {
                var data: any = res.json();

                data.Items.forEach(p => p.RatingWidthPersentage = (p.Rating * 100) / self.totalStars);

                self._photos = data.Items;
                self._page = data.Page;
                self._pagesCount = data.TotalPages;
                self._totalCount = data.TotalCount;
            },
            error => console.error('Error: ' + error));
    }

    onStarMouseMove(eventData: MouseEvent, photo: Photo) {
        var domRect = (<HTMLElement>eventData.currentTarget).getBoundingClientRect();
        var startX = domRect.left;
        var currentX = eventData.clientX;

        var deltaWidth = currentX - startX;
        var totalWidth = domRect.width;

        photo.RatingWidthPersentage = (deltaWidth * 100) / totalWidth; 
    }

    onStarMouseLeave(photo: Photo) {
        photo.RatingWidthPersentage = (photo.Rating * 100) / this.totalStars;
    }

    onStarClick(photo: Photo) {
        var vote = Math.round((photo.RatingWidthPersentage / 100) * this.totalStars * 10) / 10;

        var photoId = photo.Id;
        var userId = localStorage.getItem('userId');

        var voteData = new VoteData(+userId, +photoId, vote)

        this.photosService.set(this._photosVoteApi);
        this.photosService.post(JSON.stringify(voteData))
            .subscribe(res => {
                var data: any = res;

                if (data.Succeeded)
                    this.notificationService.printSuccessMessage(data.Message);
                else this.notificationService.printErrorMessage(data.Message);
            });
    }

    search(i): void {
        super.search(i);
        this.getPhotos();
    };
}

export class VoteData {
    userId: number;
    photoId: number;
    vote: number;

    constructor(userId: number,
        photoId: number,
        vote: number) {
        this.userId = userId;
        this.photoId = photoId;
        this.vote = vote;
    }
}