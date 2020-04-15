import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { products: [], loading: true };
  }

  componentDidMount() {
    this.ProductsData();
  }

  static renderProductsTable(products) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
            <tr>
                <th>ProductType</th>
                <th>Number</th>
                <th>Name</th>
                <th>Description</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody>
          {products.map(product =>
            <tr key={products.Id}>
                <td>{product.ProductType}</td>    
                <td>{product.Number}</td>
                <td>{product.Name}</td>
                <td>{product.Description}</td>
                <td>{product.Price}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.products);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async produtctsData() {
    const response = await fetch('productListAPI');
    const data = await response.json();
    this.setState({ products: data, loading: false });
  }
}
