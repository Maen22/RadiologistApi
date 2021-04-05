import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';

declare var ScrollReveal: any;
declare var anime: any;
declare var window: any;

function init(doc: ElementRef, strokedElement: ElementRef, circle: ElementRef) {
  console.log(anime());
  console.log('Hello from Home !');

  doc.nativeElement.classList.remove('no-js');
  doc.nativeElement.classList.add('js');

  // Reveal animations
  if (doc.nativeElement.classList.contains('has-animations')) {
    /* global ScrollReveal */
    const sr = (window.sr = ScrollReveal());

    console.log(sr);

    sr.reveal('.feature, .pricing-table-inner', {
      duration: 600,
      distance: '20px',
      easing: 'cubic-bezier(0.5, -0.01, 0, 1.005)',
      origin: 'bottom',
      interval: 100,
    });
    /* global anime */
    let heroAnimation = anime.timeline({ autoplay: true });
    console.log(heroAnimation);

    strokedElement.nativeElement.setAttribute(
      'stroke-dashoffset',
      anime.setDashoffset(strokedElement.nativeElement)
    );

    heroAnimation
      .add({
        targets: strokedElement.nativeElement,
        strokeDashoffset: {
          value: 0,
          duration: 2000,
          easing: 'easeInOutQuart',
        },
        strokeWidth: {
          value: [0, 2],
          duration: 2000,
          easing: 'easeOutCubic',
        },
        strokeOpacity: {
          value: [1, 0],
          duration: 1000,
          easing: 'easeOutCubic',
          delay: 1000,
        },
        fillOpacity: {
          value: [0, 1],
          duration: 500,
          easing: 'easeOutCubic',
          delay: 1300,
        },
      })
      .add({
        targets: '.fadeup-animation',
        offset: 1300, // Starts at 1300ms of the timeline
        translateY: {
          value: [100, 0],
          duration: 1500,
          easing: 'easeOutElastic',
          delay: 100,
        },
        opacity: {
          value: [0, 1],
          duration: 200,
          easing: 'linear',
          delay: 100,
        },
      })
      .add({
        targets: '.fadeleft-animation',
        offset: 1300, // Starts at 1300ms of the timeline
        translateX: {
          value: [40, 0],
          duration: 400,
          easing: 'easeOutCubic',
          delay: 100,
        },
        opacity: {
          value: [0, 1],
          duration: 200,
          easing: 'linear',
          delay: 100,
        },
      });

    console.log(heroAnimation);

    doc.nativeElement.classList.add('anime-ready');

    strokedElement.nativeElement.style.visibility = 'visible';
    circle.nativeElement.style.visibility = 'visible';
    let paths = document.getElementsByTagName('path');
    let circles = document.getElementsByTagName('circle');
    let rects = document.getElementsByTagName('rect');
    let uses = document.getElementsByTagName('use');
    for (let i = 0; i < paths.length; i++) {
      paths.item(i).style.visibility = 'visible';
    }
    for (let i = 0; i < circles.length; i++) {
      circles.item(i).style.visibility = 'visible';
    }
    for (let i = 0; i < circles.length; i++) {
      rects.item(i).style.visibility = 'visible';
    }
    for (let i = 0; i < circles.length; i++) {
      uses.item(i).style.visibility = 'visible';
    }
  }
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['../../assets/css/style.css'],
})
export class HomeComponent implements OnInit, AfterViewInit {
  @ViewChild('body', { static: true }) body: ElementRef;
  @ViewChild('path', { static: true }) path: ElementRef;
  @ViewChild('circle1', { static: true }) circle: ElementRef;

  isAuthenticated: boolean;

  constructor(public oktaAuth: OktaAuthService) {
    // subscribe to authentication state changes
    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => (this.isAuthenticated = isAuthenticated)
    );
  }

  ngOnInit() {}

  login() {
    this.oktaAuth.signInWithRedirect({
      originalUri: '/dash/patients',
    });
  }
  logout() {
    this.oktaAuth.signOut();
  }

  ngAfterViewInit() {
    init(this.body, this.path, this.circle);
  }
}
