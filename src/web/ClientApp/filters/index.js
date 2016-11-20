import moment from 'moment';

const formatDatePart = (part) => {
    return ('0' + (part)).slice(-2);
};

export function prependDate(value) {
    const rDate = new Date();
    const year = rDate.getFullYear();
    const month = formatDatePart(rDate.getMonth() + 1);
    const day = formatDatePart(rDate.getDate());
    const hours = formatDatePart(rDate.getHours());
    const minutes = formatDatePart(rDate.getMinutes());
    const seconds = formatDatePart(rDate.getSeconds());
    const milliSeconds = formatDatePart(rDate.getMilliseconds());
    return `${year}${month}${day}_${hours}_${minutes}_${seconds}_${milliSeconds}_${value}`;
}

export function host (url) {
  const host = url.replace(/^https?:\/\//, '').replace(/\/.*$/, '')
  const parts = host.split('.').slice(-3)
  if (parts[0] === 'www') parts.shift()
  return parts.join('.')
}

export function timeAgo (time) {
  const between = Date.now() / 1000 - Number(time)
  if (between < 3600) {
    return pluralize(~~(between / 60), ' minute')
  } else if (between < 86400) {
    return pluralize(~~(between / 3600), ' hour')
  } else {
    return pluralize(~~(between / 86400), ' day')
  }
}


function pluralize (time, label) {
  if (time === 1) {
    return time + label
  }
  return time + label + 's'
}
