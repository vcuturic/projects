import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-image-slideshow',
  templateUrl: './image-slideshow.component.html',
  styleUrls: ['./image-slideshow.component.scss']
})
export class ImageSlideshowComponent implements OnInit {

  @Input() gameScreenshotsUrls: string[] = [];

  slideIndex: number = 0;
  slidesStyle: string[] = []

  constructor() { }

  ngOnInit(): void {
    this.showSlides(this.slideIndex);
    this.gameScreenshotsUrls.forEach(sc => {
      this.slidesStyle.push("none");
    });
  }

  getScreenshotByIdFromList(i: number) {
    return this.gameScreenshotsUrls[i].replace('t_thumb', 't_screenshot_big');
  }

  plusSlides(n: number) {
    this.showSlides(this.slideIndex += n);
  }

  currentSlide(n: number) {
    this.showSlides(this.slideIndex = n);
  }

  showSlides(n: number) {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    // let dots = document.getElementsByClassName("demo");
    // let captionText = document.getElementById("caption");

    if (n > slides.length-1) {this.slideIndex = 0}
    if (n < 0) {this.slideIndex = slides.length-1}
    for (i = 0; i < slides.length; i++) {
      this.slidesStyle[i] = "none";
    }
    // for (i = 0; i < dots.length; i++) {
    //   dots[i].className = dots[i].className.replace(" active", "");
    // }
    this.slidesStyle[this.slideIndex] = "block";
    // dots[this.slideIndex-1].className += " active";
  }
}
