import { Injectable, Optional, RendererFactory2, ViewEncapsulation, Inject, Renderer2 } from '@angular/core';
import { Title } from '@angular/platform-browser';import { DOCUMENT } from "@angular/common";
import { StringUtils } from "../common/data-type-utils/string-utils";

@Injectable()

export class SeoService {
    private titleService: Title;
    private headElement: HTMLElement;
    private metaDescription: HTMLElement;
    private metaKeywords: HTMLElement;
    private robots: HTMLElement;
    private DOM: Renderer2;

    constructor(titleService: Title, private rendererFactory: RendererFactory2,
        @Inject(DOCUMENT) private document) {

        this.titleService = titleService;

        this.DOM = this.rendererFactory.createRenderer(this.document, {
                id: '-1',
                encapsulation: ViewEncapsulation.None,
                styles: [],
                data: {}
            });

        this.headElement = this.document.head;
        this.setTitle('');
        
    }

    public setSeoData(seoModel: SeoModel){
        this.setTitle(seoModel.title);
        this.setMetaRobots(seoModel.robots)
        this.setMetaDescription(seoModel.description)
        this.setMetaKeywords(seoModel.keywords)
    }

    private setTitle(newTitle: string) {
        if (StringUtils.isNullOrEmpty(newTitle)) { newTitle = "SGQ Luiz Vitor" }
        this.titleService.setTitle(newTitle + " - SGQ Luiz Vitor");
    }

    private setMetaDescription(description: string) {
        this.metaDescription = this.getOrCreateMetaElement('description');
        if (StringUtils.isNullOrEmpty(description)) { description = "O software de gestão mais robusto para Salões e Barbearias" }
        this.metaDescription.setAttribute('content', description);
    }

    private setMetaKeywords(keywords: string) {
        this.metaKeywords = this.getOrCreateMetaElement('keywords');
        if (StringUtils.isNullOrEmpty(keywords)) { keywords = "sgq, luiz, luiz vitor, puc, pos, arquitetura" }
        this.metaKeywords.setAttribute('content', keywords);
    }

    private setMetaRobots(robots: string) {
        this.robots = this.getOrCreateMetaElement('robots');
        if (StringUtils.isNullOrEmpty(robots)) { robots = "all" }
        this.robots.setAttribute('content', robots);
    }

    private getOrCreateMetaElement(name: string): HTMLElement {
        let el: HTMLElement;
        
        el = this.document.querySelector('meta[name=' + name + ']');
        if (el === null) {
            el = this.DOM.createElement('meta');
            el.setAttribute('name', name);
            this.headElement.appendChild(el);
        }
        return el;
    }
}

export class SeoModel {
    public title: string = '';
    public description: string = '';
    public robots: string = '';
    public keywords: string = '';
}

