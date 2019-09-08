export class CurrencyUtils {

    public static ToDecimal(input): any {
        if (input === null) return 0;

        input = input.replace(".", "");
        input = input.replace(",", ".");
        return parseFloat(input);
    }

    public static ToPrice(input): any {
        var ret = (input) ? input.toString().replace(".", ",") : null;
        if (ret) {
            var decArr = ret.split(",");
            if (decArr.length > 1) {
                var dec = decArr[1].length;
                if (dec === 1) { ret += "0"; }
            }
        }
        return ret;
    }
}