export const calculateCartTotal = (products) => {
    const subtotals = products.map(product => product.price * product.quantity);
    const total = subtotals.reduce((sum, value) => sum + value, 0);
    return total;
};
