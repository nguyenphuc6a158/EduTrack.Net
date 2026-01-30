import { EduTrackTemplatePage } from './app.po';

describe('EduTrack App', function () {
    let page: EduTrackTemplatePage;

    beforeEach(() => {
        page = new EduTrackTemplatePage();
    });

    it('should display message saying app works', () => {
        page.navigateTo();
        expect(page.getParagraphText()).toEqual('app works!');
    });
});
