describe('My First Test', function(){ //describe structures multiple tests
   /* it('Does not do much', function(){//it identifies individual tests
        expect(true).to.equal(true);
    });
    it('Still not doing much', function(){
        expect(true).to.equal(false);//true is expected and false is the actual value
    })*/
  /*  it('our app runs', function(){
        cy.visit('http://localhost:4200'),
        cy.get('[data-cy=filterInput]').type('Str');
        cy.get('[data-cy=productCard]').should('have.length',1);
    });*/

    it('mock product get', function(){
        cy.server({delay: 1000}); //the requests will pass throught this server
        cy.route({
            method: 'GET',
            url: 'http://localhost:4200/api/products',
            status: 200,
            response: 'fixture:products.json'
        });
        cy.visit('/');//baseurl from cypress.json
        cy.get('[data-cy=productCard]').should('have.length',3);
    });

    it('on error should show error message', function(){
        cy.server();
        cy.route({ //defining route and making sure a server error occurs when it's accessed
            method: 'GET',
            url: '/api/products',
            status: 500,
            response: 'ERROR'
        });
        cy.visit('/');
        cy.get('[data-cy=appError]').should('be.visible');
    });
});



