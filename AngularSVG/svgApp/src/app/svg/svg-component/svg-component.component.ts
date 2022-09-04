import { Component, OnInit } from '@angular/core';
import { APPROVED_COLOR, AVAILABLE_COLOR, PENDING_COLOR, SIT_APPROVED, SIT_AVAILABLE, SIT_PENDING, SIT_STATUS, SIT_UNAVAILABLE, UNAVAILABLE_COLOR } from 'src/app/common/constants/constants';

@Component({
  selector: 'app-svg-component',
  templateUrl: './svg-component.component.html',
  styleUrls: ['./svg-component.component.scss']
})
export class SvgComponentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    var svgObjects = document.getElementById('svgComponent')?.ownerDocument;
    var circles = Array.from(svgObjects?.querySelectorAll('ellipse')!);

    circles.forEach(element => {
      element.setAttribute(SIT_STATUS, SIT_AVAILABLE);

      this.setStatus(element);

      element.addEventListener('click', this.updateStatus.bind(this, element));
    });
  }

  setStatus(element: SVGEllipseElement) {
    var sitStatus = element.getAttribute(SIT_STATUS);

    if(sitStatus == SIT_APPROVED){
      element.setAttribute('fill', APPROVED_COLOR);
    }
    else if(sitStatus == SIT_PENDING){
      element.setAttribute('fill', PENDING_COLOR);
    }
    else if(sitStatus == SIT_AVAILABLE){
      element.setAttribute('fill', AVAILABLE_COLOR)
    }
    else {
      element.setAttribute('fill', UNAVAILABLE_COLOR)
    }
  }

  updateStatus(element: SVGEllipseElement) {
    var sitStatus = element.getAttribute(SIT_STATUS);

    if(sitStatus == SIT_AVAILABLE){
      element.setAttribute('fill', PENDING_COLOR);
      element.setAttribute(SIT_STATUS, SIT_PENDING);
    }
    else {
      element.setAttribute('fill', UNAVAILABLE_COLOR)
    }
  }
}
