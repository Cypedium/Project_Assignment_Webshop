import React, { Component } from 'react';

export default class Details extends Component {
        
     
        render() {
            
            const TableHeader = () => {
                return (
                    <thead>
                        <tr>
                            <th>Brand</th>
                            <th>Model</th>
                            <th>Year</th>
                            <th>Price</th>
                            <th>Options</th>                           
                        </tr>
                    </thead>
                )
            }
            const TableBody = props => {
                const rows = props.carListView.map((row) => {
                    return (                    
                            <tr key={"carId" + row.Id}>
                                <td>{row.brand}</td>
                                <td>{row.model}</td>
                                <td>{row.year}</td>
                                <td>{row.price}</td>
                                <td>
                                    <button className="btn btn-danger" onClick={() => props.removeCar(row.Id) }>Delete</button>
                                </td>
                                {" "}
                                <td>
                                    <button className="btn btn-primary" onClick={() => props.editCar(row.Id)}>Edit</button>
                                </td>                                                  
                            </tr>                    
                    )
                });
                return <tbody>{rows}</tbody>
            }
            return (
                <table>
                    <TableHeader />
                    <TableBody  carListView={this.props.carListView} removeCar={this.props.removeCar} editCar={this.props.editCar} />
                </table>
            );
        }
    
}